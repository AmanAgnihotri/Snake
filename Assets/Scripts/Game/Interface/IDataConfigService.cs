using strange.extensions.promise.api;

namespace Snake
{
  public interface IDataConfigService
  {
    IPromise<DataConfig> GetDataConfig ();
  }
}
