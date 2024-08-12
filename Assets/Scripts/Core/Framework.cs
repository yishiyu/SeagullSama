using System.Collections.Generic;
using NotImplementedException = System.NotImplementedException;
using System;
using UnityEngine.Assertions;

namespace SeagullSama.Core
{
    public class IOCContainer
    {
        private Dictionary<Type, object> _container = new Dictionary<Type, object>();

        public void Register<T>(T obj)
        {
            var type = typeof(T);
            if (_container.ContainsKey(type))
            {
                _container[type] = obj;
            }
            else
            {
                _container.Add(type, obj);
            }
        }

        public T Get<T>() where T : class
        {
            var type = typeof(T);
            if (_container.ContainsKey(type))
            {
                return _container[type] as T;
            }
            else
            {
                return null;
            }
        }
    }

    public abstract class Architecture<T> where T : Architecture<T>, new()
    {
        private static T _instance;

        public static T Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new T();
                    _instance.Init();
                }

                return _instance;
            }
        }

        // 控制反转容器
        private IOCContainer _architectureContainer = new IOCContainer();

        protected abstract void Init();


        public void RegisterManager<TManager>(TManager manager) where TManager : IManager
        {
            manager.Init();
            _architectureContainer.Register<TManager>(manager);
        }

        public void RegisterModel<TModel>(TModel model) where TModel : IModel
        {
            model.Init();
            _architectureContainer.Register<TModel>(model);
        }

        public void RegisterUtility<TUtility>(TUtility utility) where TUtility : IUtility
        {
            utility.Init();
            _architectureContainer.Register<TUtility>(utility);
        }

        public TManager GetManager<TManager>() where TManager : class, IManager
        {
            return _architectureContainer.Get<TManager>();
        }

        public TModel GetModel<TModel>() where TModel : class, IModel
        {
            return _architectureContainer.Get<TModel>();
        }

        public TUtility GetUtility<TUtility>() where TUtility : class, IUtility
        {
            return _architectureContainer.Get<TUtility>();
        }
    }

    public interface IManager
    {
        public void Init();
    }

    public interface IModel
    {
        public void Init();
    }

    public interface IUtility
    {
        public void Init();
    }


    #region EventSystem

    // 可以使用静态的 GameEvent 对象来避免 GC
    public class GameEvent
    {
    }

    // 参考自 Unity 官方项目 Micro FPS
    // 整个架构的最底层,用于底层模块触发上层模块功能
    // usage:
    // 
    // EventBus.AddListener<CameraFocusOnTargetEvent>(OnCameraFocusOnTarget);
    // EventBus.RemoveListener<CameraFocusOnTargetEvent>(OnCameraFocusOnTarget);
    //
    // var CameraFocusOnTargetEvent = new CameraFocusOnTargetEvent();
    // CameraFocusOnTargetEvent.Transform = target.transform;
    // EventBus.Invoke(CameraFocusOnTargetEvent);
    public static class EventBus
    {
        // action -> wrapper action
        private static Dictionary<Delegate, Action<GameEvent>> _actionLookups =
            new Dictionary<Delegate, Action<GameEvent>>();

        // event type -> wrapper actions
        private static Dictionary<Type, Action<GameEvent>> _eventLookups = new Dictionary<Type, Action<GameEvent>>();

        public static void AddListener<T>(Action<T> action) where T : GameEvent
        {
            if (_actionLookups.ContainsKey(action))
            {
                return;
            }

            Action<GameEvent> wrapper = (e) => action((T)e);
            _actionLookups.Add(action, wrapper);

            if (!_eventLookups.ContainsKey(typeof(T)))
            {
                // avoid to invoke a null delegate
                // because the delegate may be removed
                _eventLookups.Add(typeof(T), (e) => { });
            }

            _eventLookups[typeof(T)] += wrapper;
        }

        public static void RemoveListener<T>(Action<T> action) where T : GameEvent
        {
            if (!_actionLookups.ContainsKey(action))
            {
                return;
            }

            Action<GameEvent> wrapper = _actionLookups[action];
            _actionLookups.Remove(action);

            _eventLookups[typeof(T)] -= wrapper;
        }

        public static void Invoke(GameEvent evt)
        {
            if (!_eventLookups.ContainsKey(evt.GetType()))
            {
                return;
            }

            _eventLookups[evt.GetType()]?.Invoke(evt);
        }

        public static void Clear()
        {
            _eventLookups.Clear();
            _actionLookups.Clear();
        }
    }

    #endregion
}