using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Apng;

class Program
{
    static void Main()
    {
        // Batch definitions: each entry contains the folder with PNG frames and the target APNG file.
        var batches = new[]
        {
            new { InputFolder = @"C:\Images\Seq1", OutputFile = @"C:\Output\seq1.apng" },
            new { InputFolder = @"C:\Images\Seq2", OutputFile = @"C:\Output\seq2.apng" }
        };

        // Report file path (hard‑coded).
        string reportPath = @"C:\Output\conversion_report.txt";
        Directory.CreateDirectory(Path.GetDirectoryName(reportPath));

        using (var reportWriter = new StreamWriter(reportPath, false))
        {
            foreach (var batch in batches)
            {
                // Verify that the input folder exists.
                if (!Directory.Exists(batch.InputFolder))
                {
                    Console.Error.WriteLine($"Folder not found: {batch.InputFolder}");
                    reportWriter.WriteLine($"{batch.InputFolder} -> {batch.OutputFile}: Failed (folder not found)");
                    continue;
                }

                // Collect PNG files and sort them to preserve sequence order.
                var pngFiles = Directory.GetFiles(batch.InputFolder, "*.png");
                Array.Sort(pngFiles);

                if (pngFiles.Length == 0)
                {
                    reportWriter.WriteLine($"{batch.InputFolder} -> {batch.OutputFile}: Failed (no PNG files)");
                    continue;
                }

                // Ensure the output directory exists (unconditional per requirements).
                Directory.CreateDirectory(Path.GetDirectoryName(batch.OutputFile));

                // Verify each input file exists using the mandated pattern.
                bool allFilesExist = true;
                foreach (var file in pngFiles)
                {
                    if (!File.Exists(file))
                    {
                        Console.Error.WriteLine($"File not found: {file}");
                        allFilesExist = false;
                        break;
                    }
                }
                if (!allFilesExist)
                {
                    reportWriter.WriteLine($"{batch.InputFolder} -> {batch.OutputFile}: Failed (missing PNG file)");
                    continue;
                }

                try
                {
                    // Load the first frame to obtain image dimensions.
                    string firstFile = pngFiles[0];
                    if (!File.Exists(firstFile))
                    {
                        Console.Error.WriteLine($"File not found: {firstFile}");
                        reportWriter.WriteLine($"{batch.InputFolder} -> {batch.OutputFile}: Failed (first PNG missing)");
                        continue;
                    }

                    using (RasterImage firstFrame = (RasterImage)Image.Load(firstFile))
                    {
                        // Configure APNG creation options.
                        var createOptions = new ApngOptions
                        {
                            Source = new FileCreateSource(batch.OutputFile, false),
                            DefaultFrameTime = 100, // 100 ms per frame.
                            ColorType = PngColorType.TruecolorWithAlpha
                        };

                        // Create the APNG image with the dimensions of the first frame.
                        using (ApngImage apng = (ApngImage)Image.Create(createOptions, firstFrame.Width, firstFrame.Height))
                        {
                            // Remove the default single frame.
                            apng.RemoveAllFrames();

                            // Add each PNG as a frame.
                            foreach (var file in pngFiles)
                            {
                                using (RasterImage frame = (RasterImage)Image.Load(file))
                                {
                                    apng.AddFrame(frame);
                                }
                            }

                            // Save the assembled APNG.
                            apng.Save();
                        }
                    }

                    reportWriter.WriteLine($"{batch.InputFolder} -> {batch.OutputFile}: Success");
                }
                catch (Exception ex)
                {
                    Console.Error.WriteLine($"Error processing {batch.InputFolder}: {ex.Message}");
                    reportWriter.WriteLine($"{batch.InputFolder} -> {batch.OutputFile}: Failed ({ex.Message})");
                }
            }
        }
    }
}