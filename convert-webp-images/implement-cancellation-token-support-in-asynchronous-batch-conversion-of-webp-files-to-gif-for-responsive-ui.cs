// HOW-TO: Asynchronously Convert WebP Images To GIF With Cancellation Support In C# (Aspose.Imaging for .NET)
// ── Machine-verified example ──────────────────────────────────────────────
// Compiler-verified: built with `dotnet build` — 0 errors.
// Run-tested: executed with `dotnet run` on net9.0 — exit code 0, no unhandled exceptions.
// Exception handling: try/catch present in this example.
// Package: Aspose.Imaging 26.10.0 | Verified: 2026-10-08
// Generated and validated by an agentic workflow, not hand-written.
// ─────────────────────────────────────────────────────────────────────────────
using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Webp;

namespace WebpToGifBatch
{
    class Program
    {
        static async Task Main()
        {
            try
            {
                const string inputDirectory = "C:\\WebpInput";
                const string outputDirectory = "C:\\GifOutput";

                var cts = new CancellationTokenSource();
                Console.CancelKeyPress += (s, e) =>
                {
                    e.Cancel = true;
                    cts.Cancel();
                };

                await ProcessBatchAsync(inputDirectory, outputDirectory, cts.Token);
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine($"Error: {ex.Message}");
            }
        }

        private static async Task ProcessBatchAsync(string inputDir, string outputDir, CancellationToken token)
        {
            var webpFiles = Directory.GetFiles(inputDir, "*.webp", SearchOption.TopDirectoryOnly);
            var tasks = new Task[webpFiles.Length];

            for (int i = 0; i < webpFiles.Length; i++)
            {
                string inputPath = webpFiles[i];
                tasks[i] = Task.Run(() => ConvertWebpToGifAsync(inputPath, outputDir, token), token);
            }

            await Task.WhenAll(tasks);
        }

        private static async Task ConvertWebpToGifAsync(string inputPath, string outputDir, CancellationToken token)
        {
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            token.ThrowIfCancellationRequested();

            string fileNameWithoutExt = Path.GetFileNameWithoutExtension(inputPath);
            string outputPath = Path.Combine(outputDir, fileNameWithoutExt + ".gif");

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (var image = (WebPImage)Image.Load(inputPath))
            {
                var gifOptions = new GifOptions();
                await Task.Run(() => image.Save(outputPath, gifOptions), token);
            }

            Console.WriteLine($"Converted: {inputPath} -> {outputPath}");
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When building a desktop photo editor that lets users batch‑convert WebP assets to animated GIFs without freezing the UI, this code provides asynchronous processing with a cancel option.
 * 2. When creating a server‑side image pipeline that must quickly transform uploaded WebP files to GIF format while allowing an admin to abort the operation if it takes too long, the cancellation token ensures graceful termination.
 * 3. When developing a mobile app that downloads a collection of WebP stickers and needs to convert them to GIFs on‑device, the async batch conversion keeps the app responsive and lets users stop the conversion.
 * 4. When implementing a command‑line tool for content creators to mass‑convert WebP screenshots to GIFs, the code lets the user press Ctrl‑C to cancel the ongoing batch safely.
 * 5. When integrating Aspose.Imaging into a CI/CD workflow that processes WebP graphics into GIFs as part of asset optimization, the asynchronous pattern with cancellation helps prevent builds from hanging on large batches.
 */
