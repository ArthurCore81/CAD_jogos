using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CadJogosWF.Model
{
    public class JogosViewModel
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public float Valor { get; set; }
        public DateTime Data {  get; set; }
        public int IDCategoria { get; set; }
    }
}
