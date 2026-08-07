using System;
using System.IO;
using System.Threading;
using Aspose.Imaging;
using Aspose.Imaging.Multithreading;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.CoreExceptions;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input and output paths
            string[] inputPaths = {
                @"c:\temp\image1.png",
                @"c:\temp\image2.png"
            };

            string[] outputPaths = {
                @"c:\temp\output\image1.bmp",
                @"c:\temp\output\image2.bmp"
            };

            // Cancellation token that can be triggered by Ctrl+C
            var cts = new CancellationTokenSource();
            Console.CancelKeyPress += (sender, e) =>
            {
                e.Cancel = true; // prevent immediate termination
                cts.Cancel();
                Console.WriteLine("Cancellation requested by user.");
            };
            CancellationToken token = cts.Token;

            for (int i = 0; i < inputPaths.Length; i++)
            {
                string inputPath = inputPaths[i];
                string outputPath = outputPaths[i];

                // Verify input file exists
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                // Ensure output directory exists
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                // Process the image with interrupt support
                ProcessImage(inputPath, outputPath, token);
                
                // If cancellation was requested, stop processing further files
                if (token.IsCancellationRequested)
                {
                    Console.WriteLine("Batch processing aborted.");
                    break;
                }
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }

    static void ProcessImage(string inputPath, string outputPath, CancellationToken token)
    {
        // Create an interrupt monitor for this operation
        var monitor = new InterruptMonitor();

        // Worker thread that performs load, process, and save
        Thread workerThread = new Thread(() =>
        {
            try
            {
                // Load the image
                Image image = Image.Load(inputPath);

                // Assign the thread‑local interrupt monitor
                InterruptMonitor.ThreadLocalInstance = monitor;

                try
                {
                    // Save the image using BMP options (replace with desired options)
                    image.Save(outputPath, new BmpOptions());
                }
                catch (OperationInterruptedException)
                {
                    Console.WriteLine($"Processing of {inputPath} was interrupted.");
                }
                finally
                {
                    // Clean up
                    image.Dispose();
                    InterruptMonitor.ThreadLocalInstance = null;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        });

        workerThread.Start();

        // Monitor cancellation and request interruption if needed
        while (workerThread.IsAlive)
        {
            if (token.IsCancellationRequested)
            {
                monitor.Interrupt();
            }
            Thread.Sleep(100);
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When a desktop application must convert a large set of PNG files to BMP format and let the user stop the operation with Ctrl+C, this code provides a safe cancellation mechanism.
 * 2. When an automated image‑processing service processes dozens of images in a loop and needs to respond quickly to a shutdown signal, the CancellationToken lets the service abort the batch without leaving partially converted files.
 * 3. When a command‑line tool applies filters to high‑resolution images and the operator wants to interrupt the process if it takes too long, the token‑based approach ensures the remaining files are skipped gracefully.
 * 4. When integrating Aspose.Imaging into a CI/CD pipeline that may be cancelled by the build system, the code checks the token after each file to halt further conversions and report the cancellation.
 * 5. When building a multi‑threaded image‑conversion utility that writes output to a specific folder and must verify input existence before processing, the cancellation support allows users to abort the batch safely at any point.
 */