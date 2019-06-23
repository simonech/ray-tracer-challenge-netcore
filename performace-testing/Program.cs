using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;

namespace MyBenchmarks
{

    public class Foo 
    {
        public Foo(string text)
        {
            this.text = text;
        }

        public string text;

        public override string ToString()
        {
            return text;
        }
    }

    [RPlotExporter]
    public class StringConcatOptions
    {
        [Params(5, 10, 100, 1000, 10000)]
        public int N;

        [Params(1, 2, 4, 8, 16, 32, 64)]
        public int S;

        private string[] text;
        private Object[] foosObj;

        private Foo[] foos;

        private List<String> stringList;

        [GlobalSetup]
        public void Setup()
        {
            text = new string[N];
            foos = new Foo[N];
            foosObj = new Object[N];
            stringList = new List<string>(N);
            for (int i = 0; i < N; i++)
            {
                var sample = BuildTestString(S);
                text[i] = sample;
                foos[i] = new Foo(sample);
                foosObj[i] = new Foo(sample);
                stringList.Add(sample);
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
        public string StringConcat()
        {
            string result = string.Empty;
            for (int i = 0; i < N; i++)
            {
                result += text[i] + " ";
            }
            return result;
        }

        [Benchmark(Baseline = true)]
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
                builder.Append(foos[i].ToString());
            }
            return result.ToString();
        }

        [Benchmark]
        public string StringJoin() => String.Join(" ", text);

        [Benchmark]
        public string StringJoinOnClasses() => String.Join<Foo>(" ", foos);

        [Benchmark]
        public string StringJoinOnObjects() => String.Join(" ", foosObj);

        [Benchmark]
        public string StringJoinOnListString() => String.Join(" ", stringList);
    }


    public class Program
    {
        public static void Main(string[] args)
        {
            var summary = BenchmarkRunner.Run<StringConcatOptions>();
        }
    }
}