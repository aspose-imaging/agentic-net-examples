using System;
using System.IO;
using System.Collections.Generic;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Eps;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input EPS files
            var inputFiles = new List<string>
            {
                @"C:\Images\Input1.eps",
                @"C:\Images\Input2.eps"
            };

            // Corresponding output PNG files
            var outputFiles = new List<string>
            {
                @"C:\Images\Output\Result1.png",
                @"C:\Images\Output\Result2.png"
            };

            // Report file path
            var reportPath = @"C:\Images\Output\ConversionReport.txt";

            // Ensure the report directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(reportPath));

            using (var reportWriter = new StreamWriter(reportPath, false))
            {
                reportWriter.WriteLine("EPS Conversion Report");
                reportWriter.WriteLine($"Generated on: {DateTime.Now}");
                reportWriter.WriteLine(new string('=', 40));

                for (int i = 0; i < inputFiles.Count; i++)
                {
                    string inputPath = inputFiles[i];
                    string outputPath = outputFiles[i];

                    // Verify input file existence
                    if (!File.Exists(inputPath))
                    {
                        Console.Error.WriteLine($"File not found: {inputPath}");
                        return;
                    }

                    // Ensure output directory exists
                    Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                    // Load EPS image
                    using (var image = (EpsImage)Image.Load(inputPath))
                    {
                        // Gather metadata
                        DateTime creationDate = image.CreationDate;
                        string creator = image.Creator ?? "N/A";
                        int width = image.Width;
                        int height = image.Height;
                        var boundingBox = image.BoundingBox;

                        // Prepare PNG options with rasterization
                        var pngOptions = new PngOptions
                        {
                            VectorRasterizationOptions = new EpsRasterizationOptions
                            {
                                PageWidth = width,
                                PageHeight = height,
                                BackgroundColor = Color.White
                            }
                        };

                        // Save as PNG
                        image.Save(outputPath, pngOptions);

                        // Write entry to report
                        reportWriter.WriteLine($"Input EPS: {inputPath}");
                        reportWriter.WriteLine($"  Creator      : {creator}");
                        reportWriter.WriteLine($"  CreationDate : {creationDate}");
                        reportWriter.WriteLine($"  Dimensions   : {width}x{height}");
                        reportWriter.WriteLine($"  BoundingBox  : {boundingBox}");
                        reportWriter.WriteLine($"Output PNG: {outputPath}");
                        reportWriter.WriteLine(new string('-', 30));
                    }
                }

                reportWriter.WriteLine("Conversion completed successfully.");
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}