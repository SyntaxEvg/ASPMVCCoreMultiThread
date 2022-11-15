using Autofac;
using DI_Lesson6.Services.Impl;
using DI_Lesson6.Services;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DI_Lesson6.Autofac
{
    internal class ServiceModule :Module
    {
        protected override void Load(ContainerBuilder builder)
        {

            base.Load(builder);
            builder.RegisterType<OrderService>().As<IOrderService>().InstancePerLifetimeScope();
        }
    }
}
