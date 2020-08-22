﻿using MediatR;
using Ordering.Application.Mapper;
using Ordering.Application.Queries;
using Ordering.Application.Responses;
using Ordering.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Ordering.Application.Handlers
{
    class GetOrderByUserNameHandler : IRequestHandler<GetOrderByUserNameQuery,IEnumerable<OrderResponse>>
    {
        public readonly IOrderRepository _orderRepository;

        public GetOrderByUserNameHandler(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository ?? throw new ArgumentNullException(nameof(orderRepository));
        }

        public async Task<IEnumerable<OrderResponse>> Handle(GetOrderByUserNameQuery request, CancellationToken cancellationToken)
        {
            var orderList = await _orderRepository.GetOrderByUserName(request.UserName);
            var orderResponse = OrderMapper.Mapper.Map<IEnumerable<OrderResponse>>(orderList);
            return orderResponse;
        }
    }
}
