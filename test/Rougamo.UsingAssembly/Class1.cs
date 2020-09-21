﻿using Rougamo.Context;
using Rougamo.ImplAssembly;
using System;
using System.IO;

namespace Rougamo.UsingAssembly
{
    public class Class1
    {
        public void InstanceVoid(string stringValue, int[] intArray)
        {
            Console.WriteLine("这里是instance");
        }

        public int InstanceReturn(int seed)
        {
            var random = new Random(seed);
            for (int i = 0; i < 100; i++)
            {
                if (random.Next() == 121) return 123;
            }

            try
            {
                var x = 0;
                var y = 0;
                do
                {
                    y += random.Next();
                    if (y % 157 == 0) return y + 715;
                    if (y % 715 == 0) throw new Exception();
                } while (x++ < 100);
                return 731;
            }
            catch (Exception e)
            {
                if (random.Next() % 31 == 2) return 31;
                throw e;
            }
        }

        public int InstanceReturnSimple(int seed)
        {
            var random = new Random(seed);
            var count = 0;
            while (count++ < 100)
            {
                var rdv = random.Next();
                if (rdv % 101 == 123)
                {
                    seed = rdv;
                    break;
                }
            }
            return seed;
        }

        public static void StaticVoid(int k, int p)
        {
            var random = new Random(k | p);
            var i = 0;
            try
            {
                for (int j = 0; j < 15; j++)
                {
                    i += random.Next(17, 347);
                }
                if (i < 345) throw new UnluckilyException();
                if (i > 123456) Console.WriteLine("success"); ;
            }
            catch (IOException e)
            {
                Console.WriteLine(e);
            }
        }

        public static int StaticReturn()
        {
        start:
            var random = new Random();
            for (int i = 0; i < 100; i++)
            {
                if (random.Next() == 121) return 123;
            }

            try
            {
                var x = 0;
                var y = 0;
                do
                {
                    y += random.Next();
                    if (y % 157 == 0) return y + 715;
                    if (y % 715 == 0) throw new UnluckilyException();
                    if (y % 332 == 12) goto start;
                } while (x++ < 100);
                return 731;
            }
            catch (Exception e)
            {
                if (random.Next() % 31 == 2) return 31;
                throw e;
            }
        }
    }
}
