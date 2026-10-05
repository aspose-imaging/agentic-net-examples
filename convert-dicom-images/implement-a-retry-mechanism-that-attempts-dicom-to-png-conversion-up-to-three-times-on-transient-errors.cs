// HOW-TO: Retry DICOM to PNG Conversion Up to Three Times in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

namespace DicomToPngConverter
{
    class Program
    {
        static void Main()
        {
            try
            {
                string inputPath = "input.dcm";
                string outputPath = "output.png";

                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                string outputDir = Path.GetDirectoryName(outputPath);
                Directory.CreateDirectory(outputDir);

                const int maxAttempts = 3;
                int attempt = 0;
                while (attempt < maxAttempts)
                {
                    try
                    {
                        using (Image image = Image.Load(inputPath))
                        {
                            var pngOptions = new PngOptions();
                            image.Save(outputPath, pngOptions);
                        }
                        // Success, exit loop
                        break;
                    }
                    catch (Exception ex) when (IsTransient(ex))
                    {
                        attempt++;
                        if (attempt >= maxAttempts)
                        {
                            throw;
                        }
                        // Optionally, wait before retrying
                    }
                }
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine($"Error: {ex.Message}");
            }
        }

        private static bool IsTransient(Exception ex)
        {
            // Simple heuristic: treat IO and network related exceptions as transient
            return ex is IOException ||
                   ex is System.Net.WebException ||
                   ex is System.Net.Sockets.SocketException;
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When a hospital's PACS system intermittently fails to read DICOM files over a network, a developer can use this code to retry the conversion to PNG up to three times, ensuring the image is still generated.
 * 2. When building a batch job that extracts thumbnail PNGs from a large collection of DICOM scans, the retry logic helps handle occasional file‑system glitches without stopping the whole process.
 * 3. When deploying a cloud‑based medical imaging service where temporary network outages may occur, the code guarantees that each DICOM‑to‑PNG conversion is attempted multiple times before reporting an error.
 * 4. When integrating Aspose.Imaging into a diagnostic application that must present patient images quickly, the retry mechanism reduces the chance of user‑visible failures caused by transient I/O exceptions.
 * 5. When automating the conversion of radiology images for research datasets and the source files reside on a shared drive that can be briefly unavailable, this pattern safely retries the conversion to keep the pipeline running.
 */
