using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using StructureMap;
using StructureMap.Configuration.DSL;
using StructureMap.Configuration;
using Tailspin.Model;
using Tailspin.Infrastructure;
using Tailspin.SimpleSqlRepository;

public class Bootstrapper {
    public static void ConfigureStructureMap() {
        StructureMapConfiguration.AddRegistry(new SiteRegistry());
    }
}

public class SiteRegistry : Registry {
    protected override void configure()
    {

        ForRequestedType<IProductRepository>()
            .TheDefaultIsConcreteType<SimpleProductRepository>();

        ForRequestedType<ICustomerRepository>()
           .TheDefaultIsConcreteType<SimpleCustomerRepository>();

        ForRequestedType<IOrderRepository>()
           .TheDefaultIsConcreteType<SimpleOrderRepository>();
    }
}