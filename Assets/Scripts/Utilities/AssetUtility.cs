using System.Collections;
using System.Collections.Generic;
using SeagullSama.Core;
using UnityEngine;
using UnityEngine.Events;

namespace SeagullSama.Utility
{
    public interface IAssetUtility : IUtility
    {
        public Object LoadAsset(string abName, string resName);

        public T LoadAsset<T>(string abName, string resName) where T : Object;

        public Object LoadAsset(string abName, string resName, System.Type type);

        public void LoadAssetAsync(string abName, string resName, UnityAction<Object> callback);

        public void LoadAssetAsync<T>(string abName, string resName, UnityAction<Object> callback) where T : Object;

        public void LoadAssetAsync(string abName, string resName, System.Type type, UnityAction<Object> callback);

        public void UnLoadAssetBundle(string abName);

        public void UnLoadAllAssetBundle();
    }

    public class AssetUtility : MonoBehaviour, IAssetUtility
    {
        //防止AB包重复加载 对已经加载的AB包存储
        private Dictionary<string, AssetBundle> assetBundlesDic = new Dictionary<string, AssetBundle>();

        //加载路径

        private string assetBundleFolder
        {
            get
            {
#if UnITY_IOS
                return Application.streamingAssetsPath + "/" + "IOS/";
#elif UNITY_ANDROID
                return Application.streamingAssetsPath + "/" +"Android/";
#else
                return Application.streamingAssetsPath + "/" + "StandaloneWindows/";
#endif
            }
        }

        public void Init()
        {
            LoadAssetBundle("prefabs.assetbundle");
            Debug.Log("AssetUtility Init");
        }

        public void LoadAssetBundle(string assetBundleName)
        {
            if (!assetBundlesDic.ContainsKey(assetBundleName))
            {
                AssetBundle resAssetBundle = AssetBundle.LoadFromFile(assetBundleFolder + assetBundleName);
                assetBundlesDic.Add(assetBundleName, resAssetBundle);
            }

        }

        public Object LoadAsset(string abName, string resName)
        {
            if (assetBundlesDic.ContainsKey(abName) == false)
            {
                LoadAssetBundle(abName);
            }

            Object resObj = null;
            resObj = assetBundlesDic[abName].LoadAsset(resName);
            return resObj;
        }

        public T LoadAsset<T>(string abName, string resName) where T : Object
        {
            if (assetBundlesDic.ContainsKey(abName) == false)
            {
                LoadAssetBundle(abName);
            }

            T res = assetBundlesDic[abName].LoadAsset<T>(resName);
            return res;
        }

        public Object LoadAsset(string abName, string resName, System.Type type)
        {
            if (assetBundlesDic.ContainsKey(abName) == false)
            {
                LoadAssetBundle(abName);
            }

            Object obj = assetBundlesDic[abName].LoadAsset(resName, type);
            return obj;
        }

        //--------------------------------------------------------
        //同步加载的AB包 异步加载res资源
        public void LoadAssetAsync(string abName, string resName, UnityAction<Object> callback)
        {
            StartCoroutine(LoadAssetIEn(abName, resName, callback));
        }

        //异步加载协程
        private IEnumerator LoadAssetIEn(string abName, string resName, UnityAction<Object> callback)
        {
            if (assetBundlesDic.ContainsKey(abName) == false)
            {
                LoadAssetBundle(abName);
            }

            AssetBundleRequest request = assetBundlesDic[abName].LoadAssetAsync(resName);
            yield return request;
            callback(request.asset);
        }

        //根据泛型来异步加资源
        public void LoadAssetAsync<T>(string abName, string resName, UnityAction<Object> callback) where T : Object
        {
            StartCoroutine(LoadAssetIEn<T>(abName, resName, callback));
        }

        //异步加载协程
        private IEnumerator LoadAssetIEn<T>(string abName, string resName, UnityAction<Object> callback)
            where T : Object
        {
            if (assetBundlesDic.ContainsKey(abName) == false)
            {
                LoadAssetBundle(abName);
            }

            AssetBundleRequest request = assetBundlesDic[abName].LoadAssetAsync<T>(resName);
            yield return request;
            callback(request.asset);
        }

        //根据res类型异步加载资源
        //根据泛型来异步加资源
        public void LoadAssetAsync(string abName, string resName, System.Type type, UnityAction<Object> callback)
        {
            StartCoroutine(LoadAssetIEn(abName, resName, type, callback));
        }

        //异步加载协程
        private IEnumerator LoadAssetIEn(string abName, string resName, System.Type type,
            UnityAction<Object> callback)
        {
            if (assetBundlesDic.ContainsKey(abName) == false)
            {
                LoadAssetBundle(abName);
            }

            AssetBundleRequest request = assetBundlesDic[abName].LoadAssetAsync(resName, type);
            yield return request;
            callback(request.asset);
        }

        //资源包的卸载
        public void UnLoadAssetBundle(string abName)
        {
            if (assetBundlesDic.ContainsKey(abName))
            {
                assetBundlesDic[abName].Unload(false);
                assetBundlesDic.Remove(abName);
            }
        }

        //卸载所有加载的资源包
        public void UnLoadAllAssetBundle()
        {
            AssetBundle.UnloadAllAssetBundles(false);
            assetBundlesDic.Clear();
        }
    }
}