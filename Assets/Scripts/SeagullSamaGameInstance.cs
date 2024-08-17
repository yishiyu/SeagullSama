using System.Collections;
using System.Collections.Generic;
using SeagullSama.Controller;
using SeagullSama.Core;
using SeagullSama.Manager;
using SeagullSama.Utility;
using UnityEngine;

namespace SeagullSama
{
    public class SeagullSama : Architecture<SeagullSama>
    {
        protected override void Init()
        {
            Debug.Log("SeagullSama Init");

            // ================== 注册工具 ==================
            RegisterUtility<IInputUtility>(new InputManager());
            RegisterUtility<IDebugUtility>(new DebugUtility());
            RegisterUtility<IAssetUtility>(new AssetUtility());

            // ================== 注册模型 ==================

            // ================== 注册管理器 ==================
            RegisterManager<IGameStateManager>(new GameStateManager());
            RegisterManager<IAbilityManager>(new AbilityManager());

            // ================== 注册技能 ==================
            RegisterAbilities();
        }

        private void RegisterAbilities()
        {
            IAbilityManager abilityManager = GetManager<IAbilityManager>();
            foreach (var ability in AbilityHelper.AbilityList)
            {
                abilityManager.RegisterAbility(ability);
            }
        }
    }


    public class SeagullSamaGameInstance : MonoBehaviour
    {
        private static SeagullSamaGameInstance _instance;

        public static SeagullSamaGameInstance Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = FindObjectOfType<SeagullSamaGameInstance>();
                }

                return _instance;
            }
        }

        private void Awake()
        {
            if (_instance == null)
            {
                _instance = this;
            }


            if (_instance != this)
            {
                Destroy(gameObject);
            }
            else
            {
                DontDestroyOnLoad(this);

                Debug.Log("SeagullSama Start");

                // 初始化框架
                SeagullSama sama = SeagullSama.Instance;
            }
        }
    }
}