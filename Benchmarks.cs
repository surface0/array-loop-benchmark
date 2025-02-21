using BenchmarkDotNet.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;

namespace ArrayLoopBenchmark
{
    public class Benchmarks
    {
        private int[] array;
        private List<int> list;
        private IEnumerable<int> enumerable;

        [GlobalSetup]
        public void Setup()
        {
            array = Enumerable.Range(0, 1000).ToArray();
            list = array.ToList();
            enumerable = array;
        }

        [Benchmark]
        public int ArrayLoop()
        {
            int sum = 0;
            foreach (var item in array)
            {
                sum += item;
            }
            return sum;
        }

        [Benchmark]
        public int ListLoop()
        {
            int sum = 0;
            foreach (var item in list)
            {
                sum += item;
            }
            return sum;
        }

        [Benchmark]
        public int EnumerableLoop()
        {
            int sum = 0;
            foreach (var item in enumerable)
            {
                sum += item;
            }
            return sum;
        }

        [Benchmark]
        public int SpanLoop()
        {
            int sum = 0;
            foreach (var item in (Span<int>)array)
            {
                sum += item;
            }
            return sum;
        }

        [Benchmark]
        public int ListAsSpanLoop()
        {
            int sum = 0;
            foreach (var item in CollectionsMarshal.AsSpan(list))
            {
                sum += item;
            }
            return sum;
        }

        [Benchmark]
        public int EnumerableAsSpanLoop()
        {
            int sum = 0;
            foreach (var item in (Span<int>)enumerable.ToArray())
            {
                sum += item;
            }
            return sum;
        }
    }
}
