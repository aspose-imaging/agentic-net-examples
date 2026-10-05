// HOW-TO: Batch Convert Multiple EPS Files To PSD Using Aspose.Imaging In C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

namespace BatchEpsToPsdTest
{
    class Program
    {
        static void Main()
        {
            try
            {
                // Hardcoded input and output directories
                string inputDirectory = "TestData/Input";
                string outputDirectory = "TestData/Output";

                // List of EPS files to convert
                string[] epsFiles = { "sample1.eps", "sample2.eps", "sample3.eps" };

                foreach (var epsFile in epsFiles)
                {
                    string inputPath = Path.Combine(inputDirectory, epsFile);
                    if (!File.Exists(inputPath))
                    {
                        Console.Error.WriteLine($"File not found: {inputPath}");
                        return;
                    }

                    string outputFileName = Path.GetFileNameWithoutExtension(epsFile) + ".psd";
                    string outputPath = Path.Combine(outputDirectory, outputFileName);

                    // Ensure output directory exists
                    Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                    // Load EPS and save as PSD
                    using (Image image = Image.Load(inputPath))
                    {
                        var psdOptions = new PsdOptions();
                        image.Save(outputPath, psdOptions);
                    }

                    Console.WriteLine($"Converted '{inputPath}' to '{outputPath}'.");
                }
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine($"Error: {ex.Message}");
            }
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When you need to automatically transform a collection of EPS artwork into editable Photoshop PSD files in a .NET application.
 * 2. When you want to verify that a batch conversion process correctly creates PSD output for each EPS source during continuous integration testing.
 * 3. When you are building a migration tool that moves legacy vector graphics into Photoshop format for designers to edit further.
 * 4. When you must ensure that missing input files are detected early and reported while processing multiple EPS documents.
 * 5. When you need to generate PSD files in a specific output folder structure while preserving original file names for downstream workflows.
 */
