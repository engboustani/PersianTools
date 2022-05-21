using System;
using BenchmarkDotNet.Running;
using CommandLine;
using PersianTools;

namespace PersianTools.Cli
{
    class Program
    {
        static void Main(string[] args)
        {
            var summary = BenchmarkRunner.Run(typeof(Program).Assembly);

        }
    }
}