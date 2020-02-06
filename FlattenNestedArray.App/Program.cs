using Autofac;
using FlattenNestedArray.Library.Interfaces;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace FlattenNestedArray.App
{
    class Program
    {
        static void Main(string[] args)
        {
            var nestedArrayInput = new object[] { 1, 2, 3, 4, 5, new object[] { 6, 7, new object[] { 8, 9, new object[] { 10, 11, 12 }, 13, 14, 15, }, 16, 17 }, 18, 19, 20 };
            var container = GetContainer();
            var nestedArray = container.Resolve<INestedArray>();
            var flattenArray = nestedArray.GetFlattenArray(nestedArrayInput);
        }

        private static IContainer GetContainer()
        {
            var containerBuilder = new ContainerBuilder();
            containerBuilder.RegisterModule<Modules>();

            return containerBuilder.Build();
        }
    }
}