namespace GameFifteen.UI.Console
{
    internal abstract class EngineTemplate
    {
        public void Run()
        {
            this.Welcome();
            this.Play();
            this.Goodbye();
        }

        protected abstract void Welcome();

        protected abstract void Play();

        protected abstract void Goodbye();
    }
}