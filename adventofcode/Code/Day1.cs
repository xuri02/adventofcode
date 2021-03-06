﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
#pragma warning disable 1998

namespace adventofcode.Code
{
    public class Day1 : ISolver
    {
        private int[] numbers;
        private const int Magic = 2020;

        public ILogger<ISolver> Logger { get; set; }

        public string InFile { get; } = "numbers-1";


        public async Task Init(string data)
        {
            numbers = data.Split("\n", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
        }

        public async Task Run()
        {
            List<int> fount = new();

            foreach (var i in numbers)
            {
                foreach (var j in numbers)
                {
                    foreach (var k in numbers)
                    {
                        if (i + j + k != Magic) continue;
                        if (fount.Contains(i * j * k)) continue;

                        fount.Add(i * j * k);
                        Logger.Log(LogLevel.Information, $"{i} * {j} * {k} = {i * j * k}");
                    }

                    if (i + j != Magic) continue;
                    if (fount.Contains(i * j)) continue;

                    fount.Add(i * j);
                    Logger.Log(LogLevel.Information, $"{i} * {j} = {i * j}");
                }
            }
        }
    }
}
