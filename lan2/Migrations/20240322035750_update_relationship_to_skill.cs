using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace lan2.Migrations
{
    /// <inheritdoc />
    public partial class update_relationship_to_skill : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "SkillId",
                table: "UserSkill",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "SkillId",
                table: "JobSkill",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_UserSkill_SkillId",
                table: "UserSkill",
                column: "SkillId");

            migrationBuilder.CreateIndex(
                name: "IX_JobSkill_SkillId",
                table: "JobSkill",
                column: "SkillId");

            migrationBuilder.AddForeignKey(
                name: "FK_JobSkill_skills_SkillId",
                table: "JobSkill",
                column: "SkillId",
                principalTable: "skills",
                principalColumn: "SkillId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserSkill_skills_SkillId",
                table: "UserSkill",
                column: "SkillId",
                principalTable: "skills",
                principalColumn: "SkillId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_JobSkill_skills_SkillId",
                table: "JobSkill");

            migrationBuilder.DropForeignKey(
                name: "FK_UserSkill_skills_SkillId",
                table: "UserSkill");

            migrationBuilder.DropIndex(
                name: "IX_UserSkill_SkillId",
                table: "UserSkill");

            migrationBuilder.DropIndex(
                name: "IX_JobSkill_SkillId",
                table: "JobSkill");

            migrationBuilder.DropColumn(
                name: "SkillId",
                table: "UserSkill");

            migrationBuilder.DropColumn(
                name: "SkillId",
                table: "JobSkill");
        }
    }
}
