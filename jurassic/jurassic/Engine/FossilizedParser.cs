using jurassic.Engine.PDFTransform;
using Prehistoric;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace jurassic.Engine
{
    public class FossilizedParser
    {
        FileDownload downloader;
        private PDFTextTransformer transformer;

        public FossilizedParser(FileDownload idownloader, PDFTextTransformer iTransformer)
        {
            downloader = idownloader;
            transformer = iTransformer;

        }

        public void Run(IEnumerable<string> pdfUrls)
        {
            var pdfUris = pdfUrls.Select(x => new Uri(x));
            string baseWorkFolder = "resources";
            string pdfStore = "pdfstore";
            string textStore = "textstore";
            string fileBaseName = "test_";
            int count = 1;
            foreach (Uri pdfUri in pdfUris)
            {
                string translateFilepath = Path.Combine(baseWorkFolder, pdfStore, fileBaseName + count.ToString() + ".pdf");
                string translatedFilepath = Path.Combine(baseWorkFolder, textStore, fileBaseName + count.ToString() + ".txt");
                extract(pdfUri ,translateFilepath, translatedFilepath);
            }
        }

        private void extract(Uri target, string src, string dest)
        {
            downloader.Download(target, src);
            transformer.Transform(src, dest);
            var test = transformer.TransformToText(src);
            //var test = transformer.TransformToText_PDF2Text(src);
            File.WriteAllLines(dest, test);
        }
    }
}
