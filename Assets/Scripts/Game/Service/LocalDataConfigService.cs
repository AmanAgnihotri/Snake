using UnityEngine;
using Newtonsoft.Json;
using strange.extensions.promise.api;
using strange.extensions.promise.impl;

namespace Snake
{
  [Implements (typeof (IDataConfigService))]
  public class LocalDataConfigService : IDataConfigService
  {
    private DataConfig dataConfig;

    private IPromise<DataConfig> promise = new Promise<DataConfig> ();

    public IPromise<DataConfig> GetDataConfig ()
    {
      if (dataConfig != null)
      {
        promise.Dispatch (dataConfig);
      }
      else
      {
        LoadDataConfig ();
      }

      return promise;
    }

    private void LoadDataConfig ()
    {
      var dataConfigJson = Resources.Load<TextAsset> ("DataConfig").text;

      dataConfig = JsonConvert.DeserializeObject<DataConfig> (dataConfigJson);

      promise.Dispatch (dataConfig);
    }
  }
}
