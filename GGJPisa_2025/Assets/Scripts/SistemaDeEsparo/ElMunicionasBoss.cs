using HUD;
using Spanish;
using UnityEngine;
using UnityEngine.Serialization;

namespace SistemaDeEsparo
{
    public class ElGestorDeLeMunicionas : SoltieroComportamiento
    {
        // Variabili pubbliche per configurare munizioni iniziali
        public int MunicionMaximaNelCarigador;
        public int MaxReservaDeMunicionas;

        // Variabili per tenere traccia dello stato corrente
        public int MunicionasCorenteNelCarigador;
        public int MunicionasCorenteNeloZaino;


        [FormerlySerializedAs("fillController")]
        public FillController chargerFillController;

        public FillController InventoryFillController;

        protected override void Ajornamiendo()
        {
            chargerFillController.UpdateFill(MunicionasCorenteNelCarigador, MunicionMaximaNelCarigador);
            InventoryFillController.UpdateFill(MunicionasCorenteNeloZaino, MaxReservaDeMunicionas);
        }

        protected override void Magnana()
        {
            MunicionasCorenteNelCarigador = MunicionMaximaNelCarigador;
            MunicionasCorenteNeloZaino = MaxReservaDeMunicionas;
        }

        public void Recargar()
        {
            if (MunicionasCorenteNeloZaino > 0 && MunicionasCorenteNelCarigador < MunicionMaximaNelCarigador)
            {
                int neededAmmo = MunicionMaximaNelCarigador - MunicionasCorenteNelCarigador;
                int ammoToReload = Mathf.Min(neededAmmo, MunicionasCorenteNeloZaino);

                MunicionasCorenteNelCarigador += ammoToReload;
                MunicionasCorenteNeloZaino -= ammoToReload;
            }
        }

        public void AddAmmo(int amount)
        {
            MunicionasCorenteNeloZaino += amount;

            if (MunicionasCorenteNelCarigador > MaxReservaDeMunicionas)
            {
                MunicionasCorenteNeloZaino = MaxReservaDeMunicionas;
            }
        }
    }
}