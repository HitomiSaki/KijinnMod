using Kijinn.KijinnCode.Character;
using MegaCrit.Sts2.Core.Entities.Cards;
using STS2RitsuLib.Interop.AutoRegistration;
using STS2RitsuLib.Scaffolding.Content;

namespace Kijinn.KijinnCode.Cards;

// 设置Inherit为true允许自动注册该类的所有子类
[RegisterCard(typeof(KijinnCardPool), Inherit = true)] 
public abstract class KijinnCardModel : ModCardTemplate
{
    public override CardAssetProfile AssetProfile => new(
        PortraitPath: $"res://Kijinn/images/cards/{GetType().Name}.png",
        FramePath: GetFramePathByTagAndType()
        
        // 根据不同类型设置不同卡框
        // FramePath: Type switch
        // {
        //    CardType.Attack => "res://Kijinn/images/bg_attack.png",
        //     // CardType.Skill => "res://RitsuTest/images/card_frame_skill.png",
        //     // CardType.Power => "res://RitsuTest/images/card_frame_power.png",
        //     _ => ""
        // }
        
        // PortraitBorderPath: "",
        // BannerTexturePath: ""
    );

    private string GetFramePathByTagAndType()
    {
        // 根据是否包含特定 Tag 返回不同卡框
        //冰寒 鬼人 卡框区分
        
        //冰寒
        if (CanonicalTags.Contains(CardTag.Defend))
        {
            return base.Type switch
            {
                CardType.Attack => "res://Kijinn/images/bg_freeze_attack.png",
                CardType.Skill => "res://Kijinn/images/bg_freeze_skill.png",
                CardType.Power => "res://Kijinn/images/bg_freeze_power.png",
                _ => ""
            };
        }
        
        //鬼人
        if (CanonicalTags.Contains(CardTag.Strike))
        {
            return base.Type switch
            {
                CardType.Attack => "res://Kijinn/images/bg_kijinn_attack.png",
                CardType.Skill => "res://Kijinn/images/bg_kijinn_skill.png",
                CardType.Power => "res://Kijinn/images/bg_kijinn_power.png",
                _ => ""
            };
        }
    
        // 默认卡框
        return base.Type switch
        {
            CardType.Attack => "res://Kijinn/images/bg_attack.png",
            CardType.Skill => "res://Kijinn/images/bg_skill.png",
            CardType.Power => "res://Kijinn/images/bg_power.png",
            _ => ""
        };
    }
    
    public KijinnCardModel(int cost, CardType type, CardRarity rarity, TargetType targetType, bool shouldShowInCardLibrary)
        : base(cost, type, rarity, targetType, shouldShowInCardLibrary)
    {
    }
}