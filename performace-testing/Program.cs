using System;
using System.Security.Cryptography;
using System.Text;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;

namespace MyBenchmarks
{

    public class Foo 
    {
        public Foo(int num)
        {
            text = StringConcatOptions.BuildTestString(num);
        }

        public string text;

        public override string ToString()
        {
            return text;
        }
    }

    public class StringConcatOptions
    {
        [Params(5, 10, 100, 1000, 10000)]
        public int N;

        [Params(1, 2, 4, 8, 16, 32, 64)]
        public int S;

        private string[] text;
        private Foo[] foos;

        [GlobalSetup]
        public void Setup()
        {
            text = new string[N];
            foos = new Foo[N];
            for (int i = 0; i < N; i++)
            {

                text[i] = BuildTestString(S);
                foos[i] = new Foo(S);
            }
        }

        public static string BuildTestString(int s)
        {
            var builder = new StringBuilder();
            for (int i = 0; i < s; i++)
            {
                builder.Append("A");
            }
            return builder.ToString();
        }

        [Benchmark]
        public string StringJoin() => String.Join(" ", text);

        [Benchmark]
        public string StringConcat()
        {
            string result = string.Empty;
            for (int i = 0; i < N; i++)
            {
                result += text[i] + " ";
            }
            return result;
        }

        [Benchmark]
        public string StringBuilder()
        {
            var builder = new StringBuilder();
            string result = string.Empty;
            for (int i = 0; i < N; i++)
            {
                builder.Append(text[i]);
            }
            return result.ToString();
        }

        [Benchmark]
        public string StringBuilderOnObject()
        {
            var builder = new StringBuilder();
            string result = string.Empty;
            for (int i = 0; i < N; i++)
            {
                builder.Append(foos[i].text);
            }
            return result.ToString();
        }

        [Benchmark]
        public string StringJoinOnObjects() => String.Join<Foo>(" ", foos);
    }


    public class Program
    {
        public static void Main(string[] args)
        {
            var summary = BenchmarkRunner.Run<StringConcatOptions>();
        }
    }
}