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
            // Hardcoded input and output paths
            string inputPath = "sample.cmx";
            string outputPath = "output.txt";

            // Validate input file existence
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load CMX image and check if it is multi-page
            using (CmxImage image = (CmxImage)Image.Load(inputPath))
            {
                IMultipageImage multipage = image as IMultipageImage;
                bool isMultiPage = multipage != null && multipage.PageCount > 1;
                Console.WriteLine($"Is multi-page: {isMultiPage}");
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}