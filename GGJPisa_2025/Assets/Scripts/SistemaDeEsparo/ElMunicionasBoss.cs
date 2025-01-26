using Spanish;
using UnityEngine;

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