using Iris.DigitCounter.Engine;
using Iris.DigitCounter.Engine.Interfaces;
using Microsoft.Practices.Unity;

namespace Iris.DigitCounter
{
    public static class Bootstrapper
    {
        public static void RegisterTypes(IUnityContainer container)
        {
            container.RegisterType<IDigitCounter, MathematicalDigitCounterEngine>();
        }
    }
}
