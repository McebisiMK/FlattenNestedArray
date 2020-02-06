using Autofac;
using FlattenNestedArray.Library;
using FlattenNestedArray.Library.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace FlattenNestedArray.App
{
    public class Modules : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<NestedArray>().As<INestedArray>();
            builder.RegisterType<ObjectConverter>().As<IObjectConverter>();
        }
    }
}
