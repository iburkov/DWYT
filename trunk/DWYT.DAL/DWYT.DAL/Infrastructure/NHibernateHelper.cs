using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NHibernate;
using NHibernate.Cfg;
using DWYT.Core.DomainModels;
using System.IO;
using System.Reflection;

namespace DWYT.DAL.Infrastructure
{
    class NHibernateHelper
    {
        private static ISessionFactory _sessionFactory;
        private static ISessionFactory SessionFactory
        {
            get
            {
                if (_sessionFactory == null)
                {
                    Configuration configuration = new Configuration();
                    configuration.Configure();
                    configuration.AddAssembly(typeof(Person).Assembly);
                    _sessionFactory = configuration.BuildSessionFactory();
                }
                return _sessionFactory;
            }
        }
        public static ISession OpenSession() 
        { 
            return SessionFactory.OpenSession(); 
        }

        public static IStatelessSession OpenStatelessSession()
        {
            return SessionFactory.OpenStatelessSession();
        }
    }
}
