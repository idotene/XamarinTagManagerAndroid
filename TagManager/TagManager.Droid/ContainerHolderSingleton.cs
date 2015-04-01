using Android.Gms.Tagmanager;

namespace TagManager.Droid
{
    public class ContainerHolderSingleton
    {
        private static IContainerHolder _containerHolder;

        /**
         * Utility class; don't instantiate.
         */
        private ContainerHolderSingleton()
        {
        }

        public static IContainerHolder GetContainerHolder()
        {
            return _containerHolder;
        }

        public static void SetContainerHolder(IContainerHolder c)
        {
            _containerHolder = c;
        }
    }

}