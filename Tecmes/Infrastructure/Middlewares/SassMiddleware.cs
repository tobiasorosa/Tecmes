using LibSassHost;

namespace Tecmes.Infrastructure.Middlewares
{
    public class SassMiddleware
    {
        private readonly RequestDelegate _next;

        public SassMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            if (context.Request.Path.Value.EndsWith(".css") && context.Request.Path.Value.Contains(".scss"))
            {
                var filePath = context.Request.Path.Value.Replace(".css", ".scss").TrimStart('/');
                var fileContent = File.ReadAllText(filePath);

                var options = new CompilationOptions
                {
                    OutputStyle = OutputStyle.Compressed
                };
                var result = SassCompiler.Compile(fileContent, options);

                context.Response.ContentType = "text/css";
                await context.Response.WriteAsync(result.CompiledContent);
            }
            else
            {
                await _next(context);
            }
        }
    }
}