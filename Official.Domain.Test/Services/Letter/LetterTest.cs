using System;
using System.Collections.Generic;
using FluentAssertions;
using Official.Domain.Model.Letter;
using Xunit;

namespace Official.Domain.Test.Services.Letter
{
    public class LetterTest
    {
        [Fact]
        public void Constructor_should_construct_letter_properly()
        {
            var letter = CreateLetter(out var creatorLetter, out var type, out var subject, out var body);

            letter.CreatorLetter.Should().Be(creatorLetter);
            letter.Type.Should().Be(type);
            letter.Subject.Should().Be(subject);
            letter.Body.Should().Be(body);
        }

        [Fact]
        public void Letter_should_be_Referral_to_users()
        {
            var referralLetter = "1";
            var receiveLetter = new List<string>() { "2" };
            var letter = CreateLetter(out var creatorLetter, out var type, out var subject, out var body);

            letter.ReferralUsers(referralLetter, receiveLetter);

            letter.ReferralLetter.Should().Be(referralLetter);
            letter.ReceiveLetter.Should().BeEquivalentTo("2");
        }

        [Fact]
        public void letter_should_be_throw_exception_when_type_is_primary_and_send_to_multi_user()
        {
            var referralLetter = "1";
            var receiveLetter = new List<string>() { "2", "3" };
            var letter = CreateLetter(out var creatorLetter, out var type, out var subject, out var body);
            Action action = () => letter.ReferralUsers(referralLetter, receiveLetter);
            action.Should().Throw<Exception>();
        }

        [Fact]
        public void LetterCirculation_should_be_create_after_referral()
        {
            var referralLetter = "1";
            var receiveLetter = new List<string>() { "2", "3" };
            var letter = CreateLetter(out var creatorLetter, out var type, out var subject, out var body);
            var date = DateTime.Now;
            var expected = new List<LetterCirculation>()
            {
                new LetterCirculation(letter.Id, referralLetter, "2", date),
                new LetterCirculation(letter.Id, referralLetter, "3", date)
            };

            letter.CreateFlow(letter, referralLetter, receiveLetter, date);

            letter.LetterCirculations.Should().BeEquivalentTo(expected);
        }

        [Fact]
        public void Letter_should_be_add_to_sent_after_referral()
        {
            var referralLetter = "1";
            var receiveLetter = new List<string>() { "2" };
            var letter = CreateLetter(out var creatorLetter, out var type, out var subject, out var body);
            letter.ReferralUsers(referralLetter, receiveLetter);

            var copy = letter.CopyToSent(letter);

            copy.Sent.Should().Be(referralLetter);
        }

        private static Model.Letter.Letter CreateLetter(out string creatorLetter, out int type, out string subject, out string body)
        {
            creatorLetter = "1";
            type = 1;
            subject = "فروش مکاتبات";
            body = "راه اندازی سیستم مکاتبات اداری";

            var letter = new Model.Letter.Letter(creatorLetter, type, subject, body);
            return letter;
        }
    }
}
