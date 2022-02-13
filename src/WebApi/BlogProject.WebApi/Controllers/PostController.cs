using AutoMapper;
using BlogProject.Application.Dto;
using BlogProject.Application.Interfaces.Repository;
using BlogProject.Application.Interfaces.Rules;
using BlogProject.Application.Parameters;
using BlogProject.Application.Services;
using BlogProject.Domain.Entities;
using BlogProject.Service.Extension.Methods;
using BlogProject.Service.Extension.Rules;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogProject.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
   // [Authorize()]
    public class PostController : CustomBaseController
    {
        private readonly IService<Post> _service;
        private readonly IPostService _postService;
        private readonly IMapper _mapper;
        private readonly IRuleService _ruleService;
        private readonly IMemoryCache _memoryCache;
        public PostController(IService<Post> service,IMapper mapper,IRuleService ruleService,IPostService postService, IMemoryCache memoryCache)
        {
            _service = service;
            _mapper = mapper;
            _ruleService = ruleService;
            _postService = postService;
            _memoryCache = memoryCache;
        }

        [HttpGet]
        //[Authorize(Roles = "Editor")]
        [ResponseCache(Duration =1000,Location =ResponseCacheLocation.Any)]
        public async Task<IActionResult> GetPost([FromQuery] PageRequestParameter parameter)
        {
            if (_memoryCache.TryGetValue("posts", out List<PostDto> posts))
            {
                return CreateActionResult(CustomResponseDto<List<PostDto>>.Success(200, posts));
            }

            var postList = await _service.GetAllAsync();
            var postDtos = _mapper.Map<List<PostDto>>(postList.ToList());
            _memoryCache.Set("posts", postDtos, new MemoryCacheEntryOptions
            {
                AbsoluteExpirationRelativeToNow = System.TimeSpan.FromMinutes(30)
            });
            
            return CreateActionResult<List<PostDto>>(CustomResponseDto<List<PostDto>>.Success(200,postDtos));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var post = await _service.GetByIdAsync(id);
            var postDto = _mapper.Map<PostDto>(post);
            return CreateActionResult(CustomResponseDto<PostDto>.Success(200, postDto));
        }

        [HttpPost]
        public async Task<IActionResult> Add(PostDto postDto)
        {

            var post = await _service.AddAsync(_mapper.Map<Post>(postDto));

            var titleRulesList = _ruleService.GetTitleRules();

            if (!post.Title.IsValidTitle(titleRulesList))
            {
                return CreateActionResult(CustomResponseDto<NoContentDto>.Fail(404, "Title kurallara uymuyor"));
            }
            var postsDto = _mapper.Map<PostDto>(post);
            return CreateActionResult(CustomResponseDto<PostDto>.Success(201, postsDto));
        }

        [HttpPut]
        public async Task<IActionResult> Update(PostDto postDto)
        {
             _service.Update(_mapper.Map<Post>(postDto));            
            return CreateActionResult(CustomResponseDto<NoContentDto>.Success(204));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var post = await _service.GetByIdAsync(id);
            _service.Remove(post);
            return CreateActionResult(CustomResponseDto<NoContentDto>.Success(204));
        }

        [HttpGet("paging")]
        public IActionResult GetPosts([FromQuery] PageRequestParameter requestParameter)
        {
            requestParameter = new PageRequestParameter();
            var posts = _postService.GetAllPosts(requestParameter);
            //Response.Headers.Add("Paging",System.Text.Json.JsonSerializer.Serialize(posts.responseModel));
            return Ok(posts);
        }
    }
}
