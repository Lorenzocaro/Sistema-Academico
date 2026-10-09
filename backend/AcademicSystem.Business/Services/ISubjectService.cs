using AcademicSystem.Entities.DTOs;
using AcademicSystem.Entities.Models;

public interface ISubjectService
{
    List<SubjectResponseDto> GetAll();
    Subject? GetById(int id);
    Subject Create(Subject subject);
    Subject? Update(int id, Subject changes);   
}