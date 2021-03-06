using System;

namespace jive
{
  public interface IBackgroundThreadFactory
  {
    BackgroundThread create_for<CommandToExecute>() where CommandToExecute : DisposableCommand;
    BackgroundThread create_for(Action action);
  }

  public class BackgroundThreadFactory : IBackgroundThreadFactory
  {
    readonly DependencyRegistry registry;

    public BackgroundThreadFactory(DependencyRegistry registry)
    {
      this.registry = registry;
    }

    public BackgroundThread create_for<CommandToExecute>() where CommandToExecute : DisposableCommand
    {
      return new WorkderBackgroundThread(registry.get_a<CommandToExecute>());
    }

    public BackgroundThread create_for(Action action)
    {
      return new WorkderBackgroundThread(new AnonymousDisposableCommand(action));
    }

    class AnonymousDisposableCommand : DisposableCommand
    {
      readonly Action action;

      public AnonymousDisposableCommand(Action action)
      {
        this.action = action;
      }

      public void run()
      {
        action();
      }

      public void Dispose() {}
    }
  }
}
