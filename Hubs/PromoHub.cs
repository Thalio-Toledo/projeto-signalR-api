
using Microsoft.AspNetCore.SignalR;
using Projeto_signalR.Models;

namespace Projeto_signalR.Hubs
{
    //RPC - Remote procedure call
    public class PromoHub : Hub
    {

        public async Task CadastrarPromocao(Promocao promocao)
        {
            await Clients.Caller.SendAsync("CadastradoSucesso");
            await Clients.Others.SendAsync("ReceberPromocao", promocao);
        }
        
    }
}
