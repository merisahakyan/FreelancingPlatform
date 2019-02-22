using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Threading.Tasks;
using Core.Models.BusinessModels;
using Core.Models.FilterModels;
using Core.Models.ViewModels;
using Core.OperationInterfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProposalsController : ControllerBase
    {
        IProposalOperations _operations;
        MediaTypeFormatter _formatter;
        public ProposalsController(IProposalOperations op)
        {
            _operations = op;
            _formatter = new JsonMediaTypeFormatter();
        }
        [HttpGet("{workId}")]
        public HttpResponseMessage Get(int workId, [FromQuery] ProposalFilterModel filter)
        {
            try
            {
                var proposals = _operations.GetProposalsForWork(workId, filter).ToList();
                return new HttpResponseMessage()
                {
                    StatusCode = HttpStatusCode.OK,
                    Content = new ObjectContent<List<ProposalViewModel>>(proposals, _formatter)
                };
            }
            catch (Exception ex)
            {
                return new HttpResponseMessage()
                {
                    StatusCode = HttpStatusCode.InternalServerError,
                };
            }
        }

        [HttpGet]
        public HttpResponseMessage Get([FromQuery] ProposalFilterModel filter)
        {
            try
            {
                var proposals = _operations.GetProposals(filter).ToList();
                return new HttpResponseMessage()
                {
                    StatusCode = HttpStatusCode.OK,
                    Content = new ObjectContent<List<ProposalViewModel>>(proposals, _formatter)
                };
            }
            catch (Exception ex)
            {
                return new HttpResponseMessage()
                {
                    StatusCode = HttpStatusCode.InternalServerError,
                };
            }
        }

        [HttpPost]
        public HttpResponseMessage SubmitProposal([FromBody] ProposalModel proposal)
        {
            try
            {
                _operations.SubmitProposal(proposal);
                return new HttpResponseMessage()
                {
                    StatusCode = HttpStatusCode.OK,
                    Content = new StringContent($"Proposal added for work {proposal.WorkId} from user {proposal.UserId}")
                };
            }
            catch (Exception ex)
            {
                return new HttpResponseMessage()
                {
                    StatusCode = HttpStatusCode.InternalServerError,
                };
            }
        }
    }
}