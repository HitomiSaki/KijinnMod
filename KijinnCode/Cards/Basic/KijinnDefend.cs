using Kijinn.KijinnCode.Character;
using MegaCrit.Sts2.Core.Commands;
using MegaCrit.Sts2.Core.Entities.Cards;
using MegaCrit.Sts2.Core.GameActions.Multiplayer;
using MegaCrit.Sts2.Core.Localization.DynamicVars;
using MegaCrit.Sts2.Core.Models.CardPools;
using MegaCrit.Sts2.Core.ValueProps;
using STS2RitsuLib.Interop.AutoRegistration;
using STS2RitsuLib.Scaffolding.Content;

namespace Kijinn.KijinnCode.Cards.Basic;

// 注册卡牌到指定池（这里是无色）。如果要写自定义池看添加人物的开头
[RegisterCard(typeof(KijinnCardPool))]
// 注册成人物起始卡，后面是数量。不需要删除即可。
// [RegisterCharacterStarterCard(typeof(TestCharacter), 5)]
public class KijinnDefend() : KijinnCardModel(1, CardType.Skill, CardRarity.Basic, TargetType.Self,true)
{
    public override bool GainsBlock => true;

    // protected override HashSet<CardTag> CanonicalTags => new HashSet<CardTag> { CardTag.Defend };
    // 卡牌基础数值
    protected override IEnumerable<DynamicVar> CanonicalVars => [
        new BlockVar(5, ValueProp.Move)
    ];
    

    
    // 打出时的效果逻辑
    protected override async Task OnPlay(PlayerChoiceContext choiceContext, CardPlay cardPlay)
    {
        // await DamageCmd(DynamicVars.Damage.BaseValue)
        //     .FromCard(this)
        //     .Targeting(cardPlay.Target!)
        //     .Execute(choiceContext);
        await CreatureCmd.GainBlock(base.Owner.Creature, base.DynamicVars.Block, cardPlay);
    }

    // 升级后的效果逻辑
    protected override void OnUpgrade()
    {
        DynamicVars.Block.UpgradeValueBy(3);
    }
}