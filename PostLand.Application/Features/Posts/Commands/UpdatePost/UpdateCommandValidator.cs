using FluentValidation;

namespace PostLand.Application.Features.Posts.Commands.CreatePost
{
    public class UpdateCommandValidator : AbstractValidator<CreatePostCommand>
    {

        public UpdateCommandValidator()
        {

            RuleFor(p=> p.Title)
                .NotEmpty()
                .NotNull()
                .MaximumLength(100);
            RuleFor(p => p.Content)
            .NotEmpty()
            .NotNull()
            ;
        }
    }
}
