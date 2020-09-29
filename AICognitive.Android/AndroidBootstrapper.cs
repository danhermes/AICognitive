using System;
using Autofac;

namespace AICognitive.Droid
{
    public class AndroidBootstrapper : IBootstrapper
    {

        public void Init(ContainerBuilder builder)
        {
            builder.RegisterType<TensorflowClassifier>().Keyed<IClassifier>("OfflineClassifier");
        }
    }
}
