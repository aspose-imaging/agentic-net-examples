using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Djvu;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        // Hard‑coded input and output file paths for twenty DjVu documents.
        string[] inputPaths = new string[20];
        string[] outputPaths = new string[20];

        for (int i = 0; i < 20; i++)
        {
            // Example file names – adjust the folder as needed.
            inputPaths[i] = $@"C:\DjvuBatch\Input\document{i + 1}.djvu";
            outputPaths[i] = $@"C:\DjvuBatch\Output\document{i + 1}.pdf";
        }

        // Process each file sequentially.
        for (int i = 0; i < inputPaths.Length; i++)
        {
            string inputPath = inputPaths[i];
            string outputPath = outputPaths[i];

            // Verify that the input file exists.
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure the output directory exists.
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the DjVu document from a file stream.
            using (Stream stream = File.OpenRead(inputPath))
            {
                using (DjvuImage djvuImage = new DjvuImage(stream))
                {
                    // Save the entire DjVu document as a PDF using default options.
                    djvuImage.Save(outputPath, new PdfOptions());
                }
            }
        }
    }
}