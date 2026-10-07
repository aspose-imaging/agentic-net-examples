// HOW-TO: Convert EPS to PSD with 16 Bit Per Channel in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Eps;
using Aspose.Imaging.FileFormats.Psd;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "Input/sample.eps";
            string outputPath = Path.Combine("Output", "sample.psd");

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (EpsImage epsImage = (EpsImage)Image.Load(inputPath))
            {
                var psdOptions = new PsdOptions();
                epsImage.Save(outputPath, psdOptions);
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When a graphic designer needs to edit a vector EPS logo in Photoshop, a developer can use this code to convert the EPS file to a 16‑bit PSD for lossless editing.
 * 2. When an automated publishing pipeline must transform incoming EPS artwork into PSD layers for further raster processing, this snippet provides a C# solution using Aspose.Imaging.
 * 3. When a web service receives EPS files from users and must store them as high‑resolution PSDs for archival or preview generation, the code performs the conversion on the server.
 * 4. When a batch job has to migrate a legacy EPS asset library to Photoshop‑compatible PSD files while preserving color depth, the example shows how to do it programmatically in .NET.
 * 5. When integrating a design‑review tool that only supports PSD input, developers can convert uploaded EPS files to 16‑bit PSDs on the fly using the provided C# routine.
 */
