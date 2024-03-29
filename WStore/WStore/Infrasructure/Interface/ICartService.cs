﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WStore.Models;

namespace WStore.Infrasructure.Interface
{
    public interface ICartService
    {
        void AddToCart(int id);

        void DecrementFromCart(int id);

        void RemoveFromCart(int id);

        void RemoveAll();

        CartViewModel TransformFromCart();
    }
}
