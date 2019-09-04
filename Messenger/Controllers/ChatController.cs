using AutoMapper;
using Messenger.Data.Entities;
using Messenger.Services.Interfaces;
using Messenger.Web.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using System.Threading.Tasks;


namespace Messenger.Web.Controllers
{
    [Route("api/[controller]")]
    public class ChatController : Controller
    {
        private readonly IChatService chatService;
        private readonly UserManager<User> userManager;
        private readonly IMapper mapper;

        public ChatController(IChatService chatService, UserManager<User> userManager, IMapper mapper)
        {
            this.chatService = chatService;
            this.userManager = userManager;
            this.mapper = mapper;
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateChatViewModel model)
        {
            var result = await chatService.Create(mapper.Map<Chat>(model));

            if (result.IsSuccessed)
                return Ok(result.Result);

            return BadRequest(result.ErrorMessage);
        }
        [HttpPost]
        public async Task<IActionResult> Update(UpdateChatViewModel model)
        {
            var result = await chatService.Update(mapper.Map<Chat>(model));

            if (result.IsSuccessed)
                return Ok(result.Result);

            return BadRequest(result.ErrorMessage);
        }
        [HttpDelete]
        public async Task<IActionResult> Delete(string chatId)
        {
            var result = await chatService.Delete(chatId);

            if (result.IsSuccessed)
                return Ok(result.IsSuccessed);

            return BadRequest(result.ErrorMessage);
        }
        [HttpPost]
        public async Task<IActionResult> ClearHistory(string chatId)
        {
            var userId = User.FindFirst(ClaimTypes.Name).Value;
            var result = await chatService.ClearHistory(userId, chatId);

            if (result.IsSuccessed)
                return Ok(result.Result);

            return BadRequest(result.ErrorMessage);
        }
        [HttpPost]
        public async Task<IActionResult> AddUserToChat(string chatId, string userId)
        {
            var result = await chatService.AddUserToChat(userId, chatId);

            if (result.IsSuccessed)
                return Ok(result.Result);

            return BadRequest(result.ErrorMessage);
        }
        [HttpPost]
        public async Task<IActionResult> RemoveUserFromChat(string chatId, string userId)
        {
            var result = await chatService.RemoveUserFromChat(userId, chatId);

            if (result.IsSuccessed)
                return Ok(result.Result);

            return BadRequest(result.ErrorMessage);
        }
    }
}
