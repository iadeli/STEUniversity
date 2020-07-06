using System;
using System.Collections.Generic;
using System.Text;
using FluentAssertions;
using Xunit;

namespace Official.Domain.Test.Services.Cartbot
{
    public class CartbotTest
    {
        [Fact]
        public void Constructor_should_be_construct_properly()
        {
            var name = "کارتابل اداری";
            var userId = "1";

            var cartbot = new Model.Cartbot.Cartbot(name, userId);

            cartbot.Name.Should().Be(name);
            cartbot.UserId.Should().Be(userId);
        }

        [Fact]
        public void Cartbot_should_be_add_recive_letter()
        {
            var creatorLetter = "1";
            int type = 1;
            var subject = "فروش مکاتبات";
            var body = "راه اندازی سیستم مکاتبات اداری";
            var letter = new Model.Letter.Letter(creatorLetter, type, subject, body);

            var name = "کارتابل اداری";
            var userId = "1";
            var cartbot = new Model.Cartbot.Cartbot(name, userId);


            cartbot.AddLetter(new List<Model.Letter.Letter>() { letter });

            cartbot.Letters.Should().Contain(letter);
        }
    }
}
