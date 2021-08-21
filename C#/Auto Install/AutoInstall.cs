using System.Collections.Generic;
using System.Linq;

namespace XRL.World.Parts.Skill
{
    public class AutoInstall : BaseSkill
    {
        public override bool WantEvent(int ID, int cascade) => ID == EndTurnEvent.ID;

        public override bool HandleEvent(EndTurnEvent E)
        {
            List<GameObject> equipped_items = new List<GameObject>();
            foreach (var (i, p) in from i in
                                       from GameObject i in ThePlayer.GetEquippedObjects()
                                       where i.HasPart("EnergyCellSocket")
                                       where GetCell(i) != null
                                       select i
                                   from IPart p in i.PartsList
                                   select (i, p))
            {
                try
                {
                    if (((IActivePart)p).ChargeUse > GetEnergyCell(i).Charge)
                    {
                        equipped_items.Add(i);
                        break;
                    }
                }
                catch
                {
                }
            }

            List<GameObject> inventory_cells = (from GameObject c in ThePlayer.GetInventory()
                                                where c.HasPart("EnergyCell")
                                                select c).ToList();

            if (equipped_items.Count > 0 && inventory_cells.Count > 0)
            {
                foreach (GameObject e in equipped_items)
                {
                    GetCellSocket(e).AttemptRemoveCell(ThePlayer, InventoryActionEvent.FromPool(ThePlayer, e));

                    if (GetCell(e) == null)
                    {
                        inventory_cells = SortByCharge(inventory_cells);
                        GameObject cell = inventory_cells[0];
                        cell = ((Stacker)cell.GetPart("Stacker")).RemoveOne();
                        GetCellSocket(e).SetCell(cell);
                        AddPlayerMessage($"You pop in {cell.a}{cell.DisplayName}.");

                        if (inventory_cells.Count == 0)
                        {
                            break;
                        }
                    }
                }
            }

            return true;
        }

        public static EnergyCell GetEnergyCell(GameObject item) => (EnergyCell)((EnergyCellSocket)item.GetPart("EnergyCellSocket")).Cell.GetPart("EnergyCell");

        public static GameObject GetCell(GameObject item) => ((EnergyCellSocket)item.GetPart("EnergyCellSocket")).Cell;

        public static EnergyCellSocket GetCellSocket(GameObject item) => (EnergyCellSocket)item.GetPart("EnergyCellSocket");

        public static List<GameObject> SortByCharge(List<GameObject> energy_cells)
        {
            for (int j = 1; j < energy_cells.Count; j++)
            {
                for (int i = j; i > 0 && ((EnergyCell)energy_cells[i].GetPart("EnergyCell")).Charge > ((EnergyCell)energy_cells[i - 1].GetPart("EnergyCell")).Charge; i--)
                {
                    GameObject i_o = energy_cells[i];
                    GameObject j_o = energy_cells[i - 1];

                    energy_cells[i] = j_o;
                    energy_cells[i - 1] = i_o;
                }
            }

            return energy_cells;
        }

        public override bool AddSkill(GameObject GO)
        {
            return base.AddSkill(GO);
        }

        public override bool RemoveSkill(GameObject GO)
        {
            return base.RemoveSkill(GO);
        }
    }
}