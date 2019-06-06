namespace codeclimber.raytracer.xUnit
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using Xunit;
    public class CanvasTest
    {
        [Fact]
        public void CanvasSetsWidthAndHeight()
        {
            //Given
            var c = new Canvas(10, 20);

            //When

            //Then
            Assert.Equal(10, c.Width);
            Assert.Equal(20, c.Height);
        }

        [Fact]
        public void EmptyCanvasIsAllBlack()
        {
            //Given
            var c = new Canvas(10, 20);

            //When

            //Then
            for (int x = 0; x < c.Width; x++)
            {
                for (int y = 0; y < c.Height; y++)
                {
                    Assert.Equal(Color.Black, c[x, y]);
                }
            }
        }

        [Fact]
        public void CanSetPixelColor()
        {
            //Given
            var c = new Canvas(10, 20);
            var red = new Color(1, 0, 0);

            //When
            c[2, 3] = red;
            //Then
            Assert.Equal(red, c[2, 3]);
        }

        [Fact]
        public void CanWritePPMHeader()
        {
            //Given
            var c = new Canvas(5, 3);
            //When
            var ppm = c.GetPPMContent();
            //Then
            var ppmLines = GetLines(ppm);
            Assert.Equal("P3", ppmLines[0]);
            Assert.Equal("5 3", ppmLines[1]);
            Assert.Equal("255", ppmLines[2]);
        }

        [Fact]
        public void CanWritePixelData()
        {
            //Given
            var c = new Canvas(5, 3);
            var c1 = new Color(1.5, 0, 0);
            var c2 = new Color(0, 0.5, 0);
            var c3 = new Color(-0.5, 0, 1);
            //When
            c[0, 0] = c1;
            c[2, 1] = c2;
            c[4, 2] = c3;
            var ppm = c.GetPPMContent();
            //Then
            var ppmLines = GetLines(ppm);
            Assert.Equal("255 0 0 0 0 0 0 0 0 0 0 0 0 0 0", ppmLines[3]);
            Assert.Equal("0 0 0 0 0 0 0 128 0 0 0 0 0 0 0", ppmLines[4]);
            Assert.Equal("0 0 0 0 0 0 0 0 0 0 0 0 0 0 255", ppmLines[5]);
        }

        [Fact]
        public void CanWritePixelLineLessThan70()
        {
            //Given
            var c = new Canvas(10, 20, new Color(1, 0.8, 0.6));
            var ppm = c.GetPPMContent();
            //Then
            var ppmLines = GetLines(ppm);
            Assert.Equal("255 204 153 255 204 153 255 204 153 255 204 153 255 204 153 255 204", ppmLines[3]);
            Assert.Equal("153 255 204 153 255 204 153 255 204 153 255 204 153", ppmLines[4]);
            Assert.Equal("255 204 153 255 204 153 255 204 153 255 204 153 255 204 153 255 204", ppmLines[5]);
            Assert.Equal("153 255 204 153 255 204 153 255 204 153 255 204 153", ppmLines[6]);
        }

        [Fact]
        public void FileEndsWithNewLine()
        {
            //Given
            var c = new Canvas(5, 3);
            //When
            var ppm = c.GetPPMContent();
            //Then

            Assert.True(ppm.EndsWith(Environment.NewLine));
        }

        [Fact]
        public void CanSaveFile()
        {
            //Given
            var c = new Canvas(10, 20, new Color(1, 0.8, 0.6));
            //When
            var c1 = new Color(1.5, 0, 0);
            var c2 = new Color(0, 0.5, 0);
            var c3 = new Color(-0.5, 0, 1);
            //When
            c[0, 0] = c1;
            c[2, 1] = c2;
            c[4, 2] = c3;
            c.Save("file.ppm");
            //Then
            Assert.True(File.Exists("file.ppm"));
        }

        private List<string> GetLines(string text)
        {
            var lines = new List<string>();
            using (StringReader reader = new StringReader(text))
            {
                while (true)
                {
                    var line = reader.ReadLine();
                    if (line != null)
                    {
                        lines.Add(line);
                    }
                    else
                    {
                        break;
                    }
                }
            }
            return lines;
        }
    }
}