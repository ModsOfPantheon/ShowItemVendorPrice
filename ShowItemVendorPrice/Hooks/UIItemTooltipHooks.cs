using HarmonyLib;
using Il2Cpp;
using Il2CppTMPro;
using MelonLoader;

namespace ShowItemVendorPrice.Hooks;

[HarmonyPatch(typeof(UIItemTooltip), nameof(UIItemTooltip.Show))]
public class UIItemTooltipHooks
{
    private static void Postfix(UIItemTooltip __instance, Item item)
    {
        var coinValue = item.Template.CoinValue;
        
        var mithril = coinValue / 1000000;
        coinValue %= 1000000;
        
        var platinum = coinValue / 100000;
        coinValue %= 100000;
        
        var gold = coinValue / 10000;
        coinValue %= 10000;
        
        var silver = coinValue / 100;
        coinValue %= 100;
        
        var copper = coinValue;
        
        var merchantValueRoot = UIItemTooltip.Instance.merchantValueRoot;
        merchantValueRoot.active = true;

        var mithrilText = merchantValueRoot.transform.GetChild(1);
        mithrilText.GetComponent<TextMeshProUGUI>().text = mithril.ToString();
        var platinumText = merchantValueRoot.transform.GetChild(2);
        platinumText.GetComponent<TextMeshProUGUI>().text = platinum.ToString();
        var goldText = merchantValueRoot.transform.GetChild(3);
        goldText.GetComponent<TextMeshProUGUI>().text = gold.ToString();
        var silverText = merchantValueRoot.transform.GetChild(4);
        silverText.GetComponent<TextMeshProUGUI>().text = silver.ToString();
        var copperText = merchantValueRoot.transform.GetChild(5);
        copperText.GetComponent<TextMeshProUGUI>().text = copper.ToString();
    }
}