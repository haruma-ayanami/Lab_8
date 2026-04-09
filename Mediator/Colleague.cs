namespace Lab8_PrintSystem.Mediator
{
    public abstract class Colleague
    {
        protected IMediator Mediator;

        public void SetMediator(IMediator mediator)
        {
            Mediator = mediator;
        }
    }
}