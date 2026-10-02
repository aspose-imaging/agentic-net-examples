// HOW-TO: Copy Large JPEG2000 Files in Parallel with Buffered Streams in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using System.Threading.Tasks;

namespace Jp2Processor
{
    class Program
    {
        static void Main()
        {
            try
            {
                string inputDirectory = "C:\\Data\\Jp2Input";
                string outputDirectory = "C:\\Data\\Jp2Output";

                var inputFiles = Directory.GetFiles(inputDirectory, "*.jp2", SearchOption.AllDirectories);

                ParallelOptions parallelOptions = new ParallelOptions
                {
                    MaxDegreeOfParallelism = Environment.ProcessorCount
                };

                Parallel.ForEach(inputFiles, parallelOptions, inputPath =>
                {
                    if (!File.Exists(inputPath))
                    {
                        Console.Error.WriteLine($"File not found: {inputPath}");
                        return;
                    }

                    string relativePath = Path.GetRelativePath(inputDirectory, inputPath);
                    string outputPath = Path.Combine(outputDirectory, relativePath);

                    Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                    const int bufferSize = 81920;
                    using (FileStream sourceStream = new FileStream(inputPath, FileMode.Open, FileAccess.Read, FileShare.Read, bufferSize, useAsync: false))
                    using (FileStream destinationStream = new FileStream(outputPath, FileMode.Create, FileAccess.Write, FileShare.None, bufferSize, useAsync: false))
                    {
                        byte[] buffer = new byte[bufferSize];
                        int bytesRead;
                        while ((bytesRead = sourceStream.Read(buffer, 0, buffer.Length)) > 0)
                        {
                            destinationStream.Write(buffer, 0, bytesRead);
                        }
                    }
                });
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
 * 1. When you need to duplicate a massive archive of JPEG2000 images to another folder while preserving the original directory hierarchy and minimizing memory usage.
 * 2. When you want to speed up batch conversion or migration of JPEG2000 files by leveraging all CPU cores with Parallel.ForEach.
 * 3. When processing high‑resolution satellite or medical images stored as JP2 and you must read and write them efficiently without loading entire files into memory.
 * 4. When building an automated pipeline that copies JP2 assets from a source repository to a deployment location on a server with limited RAM.
 * 5. When you require a reliable way to copy large JP2 files in a .NET application while handling missing files gracefully and ensuring thread‑safe directory creation.
 */
