using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Cmx;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "sample.cmx";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            using (CmxImage image = (CmxImage)Image.Load(inputPath))
            {
                bool isMultiPage = false;
                if (image is IMultipageImage multipageImage)
                {
                    isMultiPage = multipageImage.PageCount > 1;
                }
                Console.WriteLine($"Is multi-page: {isMultiPage}");
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}