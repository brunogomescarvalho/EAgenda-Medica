using System.Text.Json;

namespace eAgendaWebApi.Configs
{
    public class ManipuladorExcessoes
    {

        readonly RequestDelegate requestDelegate;

        public ManipuladorExcessoes(RequestDelegate requestDelegate)
        {
            this.requestDelegate = requestDelegate;
        }

        public async Task Invoke(HttpContext ctx)
        {
            try
            {
                await requestDelegate(ctx);
            }
            catch (Exception ex)
            {
                ctx.Response.StatusCode = 500;
                ctx.Response.ContentType = "application/json";

                var resposta = new
                {
                    sucesso = false,
                    erros = ex.Message
                };

                await ctx.Response.WriteAsync(JsonSerializer.Serialize(resposta));
            }
        }
    }
}
