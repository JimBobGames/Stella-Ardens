using System.Collections.Generic;

namespace StellaArdens.Core.Data
{
    public interface IStellaArdensGame
    {
        IReadOnlyList<Nation> NationsListUnsorted { get; }
        IReadOnlyList<Nation> NationsListAlphabetical { get; }
        Nation GetNation(int id);
        IReadOnlyList<Hull> HullsListUnsorted { get; }
        IReadOnlyList<Hull> HullsListAlphabetical { get; }
        Hull GetHull(int id);
        IReadOnlyList<Design> DesignsListUnsorted { get; }
        IReadOnlyList<Design> DesignsListAlphabetical { get; }
        Design GetDesign(int id);
        GalacticMap GalacticMap { get; }
        Fleet GetFleet(int id);
        TaskForce GetTaskForce(int id);
        Division GetDivision(int id);
        Ship GetShip(int id);

        Player Player { get; set; }
    }
}