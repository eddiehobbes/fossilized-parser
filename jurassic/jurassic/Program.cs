using jurassic.Engine;
using jurassic.Engine.PDFTransform;
using Prehistoric;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace jurassic
{
    class Program
    {
        static void Main(string[] args)
        {
            FossilizedParser parser = new FossilizedParser(new FileDownload(), new PDFTextTransformer());
            parser.Run(args);

        }
    }
}
