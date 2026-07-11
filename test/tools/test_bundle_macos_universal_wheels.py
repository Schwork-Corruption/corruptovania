from tools.bundle_macos_universal_wheels import (
    WheelInfo,
    build_wheel_plan,
    parse_macos_platform,
    parse_wheel_filename,
)


def test_parse_wheel_filename():
    wheel = parse_wheel_filename(
        "https://files.pythonhosted.org/packages/example/pkg-1.0.0-cp312-cp312-macosx_10_13_x86_64.whl"
    )

    assert wheel.filename == "pkg-1.0.0-cp312-cp312-macosx_10_13_x86_64.whl"
    assert wheel.python_tag == "cp312"
    assert wheel.abi_tag == "cp312"
    assert wheel.platform_tag == "macosx_10_13_x86_64"


def test_parse_macos_platform():
    arch, version = parse_macos_platform("macosx_12_0_universal2")

    assert arch == "universal2"
    assert version == (12, 0)


def test_prefers_existing_universal2_wheel():
    plan = build_wheel_plan(
        [
            WheelInfo(
                "pkg-1.0.0-cp312-cp312-macosx_12_0_universal2.whl",
                "cp312",
                "cp312",
                "macosx_12_0_universal2",
                "https://example/universal2",
            ),
            WheelInfo(
                "pkg-1.0.0-cp312-cp312-macosx_10_13_x86_64.whl",
                "cp312",
                "cp312",
                "macosx_10_13_x86_64",
                "https://example/x86",
            ),
            WheelInfo(
                "pkg-1.0.0-cp312-cp312-macosx_11_0_arm64.whl",
                "cp312",
                "cp312",
                "macosx_11_0_arm64",
                "https://example/arm",
            ),
        ]
    )

    assert plan is not None
    assert plan.kind == "download"
    assert plan.wheels[0].platform_tag == "macosx_12_0_universal2"


def test_selects_split_arch_merge_pair():
    plan = build_wheel_plan(
        [
            WheelInfo(
                "pkg-1.0.0-cp312-cp312-macosx_10_13_x86_64.whl",
                "cp312",
                "cp312",
                "macosx_10_13_x86_64",
                "https://example/x86",
            ),
            WheelInfo(
                "pkg-1.0.0-cp312-cp312-macosx_11_0_arm64.whl",
                "cp312",
                "cp312",
                "macosx_11_0_arm64",
                "https://example/arm",
            ),
        ]
    )

    assert plan is not None
    assert plan.kind == "merge"
    assert {wheel.platform_tag for wheel in plan.wheels} == {"macosx_10_13_x86_64", "macosx_11_0_arm64"}


def test_falls_back_to_pure_python_wheel():
    plan = build_wheel_plan(
        [
            WheelInfo("pkg-1.0.0-py3-none-any.whl", "py3", "none", "any", "https://example/pure"),
            WheelInfo(
                "pkg-1.0.0-cp311-cp311-macosx_10_13_x86_64.whl",
                "cp311",
                "cp311",
                "macosx_10_13_x86_64",
                "https://example/old",
            ),
        ]
    )

    assert plan is not None
    assert plan.kind == "download"
    assert plan.wheels[0].platform_tag == "any"
